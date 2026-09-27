# switch_tables: decode the jump targets of a Mono AOT SWITCH patch (GOT slot) of the DSSRacing binary.
# Usage: python switch_tables.py <Assembly> <got_slot> <method_start_hex> [<got_slot> <method_start_hex> ...]
# Mono 2.x encodes MONO_PATCH_INFO_SWITCH as: table_size, then one value per entry = target offset from the
# method's code start. Prints "case <value> -> <address>" so the case bodies in a listing can be matched.
import sys
from aotlift import World


def decode(mod, slot):
    off = mod.b.u32(mod.g['got_info_offsets'] + 4 * slot)
    p = mod.gi + off
    t, p = mod.dv(p)
    if t != 8:
        raise ValueError('GOT slot %d is patch type %d, not SWITCH' % (slot, t))
    n, p = mod.dv(p)
    vals = []
    for _ in range(n):
        v, p = mod.dv(p)
        vals.append(v)
    return vals


if __name__ == '__main__':
    w = World()
    mod = w.mods[sys.argv[1]]
    args = sys.argv[2:]
    for i in range(0, len(args), 2):
        slot, start = int(args[i]), int(args[i + 1], 16)
        print('GOT[%d] method @0x%x' % (slot, start))
        for k, v in enumerate(decode(mod, slot)):
            print('  case %d -> 0x%x (+0x%x)' % (k, start + v, v))

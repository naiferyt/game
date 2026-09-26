import glob, os, re, collections
from scene import parse, guid2script, summarize
S=r"C:\Users\STEEP\Documents\game work\phase2_extraction\AssetRipperUnityProject\ExportedProject\Assets\Scenes"
files=sorted(glob.glob(os.path.join(S,'Tracks','*.unity')))+[os.path.join(S,'Test Scenes','Pranksgiving Test.unity')]
keys=['RaceManager','RaceSettings','DebugTrackStrapper','CarAIPathManager','ProgressTriggerLogic','ResetTrigger','WaypointLogic','SpeedPoint','CoinPoint','BasePickup','PickupSpawner','TerrainEffectTrigger','HUDLogic','FollowCamera','PreRaceCamera','TrackHazard']
allmb=collections.Counter()
print('track'.ljust(26),'poles lapLine laps? '+' '.join(k[:10] for k in keys))
for f in files:
    out,go,comps=summarize(f,0)
    c=collections.Counter()
    for g,cl in comps.items():
        for name,fid,body in cl:
            c[name]+=1; allmb[name]+=1
    poles=sum(1 for n in go.values() if n.startswith('Pole Position'))
    laplines=0
    for g,cl in comps.items():
        for name,fid,body in cl:
            if name=='ProgressTriggerLogic' and 'isLapLine: 1' in body: laplines+=1
    paths=0
    for g,cl in comps.items():
        for name,fid,body in cl:
            if name=='CarAIPathManager': paths=body.count('- pathPoints:')
    print(os.path.basename(f)[:-6].ljust(26),str(poles).ljust(5),str(laplines).ljust(7),'aipaths=%d'%paths,' '.join(str(c[k]).rjust(3) for k in keys))

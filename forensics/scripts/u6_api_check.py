# Checks which legacy Unity 4 APIs used by the game still exist in the installed Unity 6 editor.
# Usage: python u6_api_check.py "C:/Program Files/Unity/Hub/Editor/6000.6.3f1/Editor/Data/Managed/UnityEngine"
import sys, glob, os
from climeta import PE
M=sys.argv[1]
want={'TextMesh','Animation','AnimationState','ParticleEmitter','ParticleAnimator','ParticleRenderer','EllipsoidParticleEmitter',
      'GUILayer','GUIText','GUITexture','Halo','WWW','Application','SceneManager','Input','Touch','LightmapSettings','LightmapData',
      'ParticleSystem','Projector','Camera','Rigidbody','AudioSource','PlayerPrefs','Resources','AssetBundle'}
found={}
for f in glob.glob(os.path.join(M,'*.dll')):
    try: pe=PE(f)
    except Exception: continue
    for ns,nm,fl,ml in pe.types:
        if nm in want and ns.startswith('UnityEngine'): found.setdefault(nm,[]).append(os.path.basename(f))
for w in sorted(want): print(w, found.get(w,'** NOT PRESENT **'))

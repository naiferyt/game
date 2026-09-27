# Textual rewrites applied to a temporary copy of the sources before type-checking against Unity 4.3:
# Unity 6 static APIs of UnityEngine.Object (cannot be shimmed) -> their Unity 4.3 equivalents.
s/Object\.FindObjectsByType<\([A-Za-z_0-9.]*\)>(FindObjectsSortMode\.None)/Object.FindObjectsOfType<\1>()/g
s/Object\.FindAnyObjectByType<\([A-Za-z_0-9.]*\)>()/Object.FindObjectOfType<\1>()/g

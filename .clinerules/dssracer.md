# Reglas del proyecto DSSRacer (se cargan solas en Cline)

1. Antes de hacer nada, LEE ENTEROS `AGENTS.md` y la sección "Etapa 4" de `RECOVERY_PROGRESS.md`. Ahí están el método, las herramientas y el estado.
2. Responde al usuario en español.
3. Trabaja una sola clase cada vez: lee su listado ARM (`recovery/aot_listings/...`), tradúcela y ejecuta `compile_check.py`. No sigas si hay errores.
4. No inventes código. Si no entiendes el ARM de un método, déjalo con `RecoveryPending.Hit(...)` y anótalo.
5. Nunca modifiques `phase1_analysis/` ni `phase2_extraction/`. No hagas `push --force` ni `reset --hard`, y no borres archivos sin preguntar.
6. Antes de cada commit, restaura los assets que ensucia el editor (sección 4.1 de `AGENTS.md`) y usa la identidad STEEP.
7. No marques un bloque como terminado sin haberlo probado en Unity con `run_play.sh` o `run_player.sh` y sin haber mirado las capturas.

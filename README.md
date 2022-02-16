# VContainer Sample

Samples to cover VContainer (Unity DI framework) basic usage.

Features:
- Root level / scene lifetime scopes
- Entry points
- Lifetime callbacks
- Factories / custom registrations
- Disposables
- Codegen

Architecture layers:
- **Manager** - logics related to some gameplay scope, which uses services to perform required tasks
- **Scope** - composition roots for dependency injection
- **Service** - utilities to perform specific tasks
- **Starter** - entry points for each scene (no/minimal logics)
- **State** - persistant save data only 
- **View** - MonoBehaviour components
# Namespace System

El namespace System es la API proporcionada por el motor de ejecución de los contratos inteligentes (Neo-VM), este porporciona una forma de acceso al entorno de ejecución del contrato inteligente.

| API | Descripción |
| ---------------------------------------- | -------------------------- |
| System.ExecutionEngine.GetScriptContainer | Devuelve el script contenedor para este contrato inteligente. (el primer trigger) |
| System.ExecutionEngine.GetExecutingScriptHash | Devuelve el hash del script de la ejecución del contrato inteligente. |
| System.ExecutionEngine.GetCallingScriptHash | Devuelve el hash del script del solicitante para este contrato inteligente. |
| System.ExecutionEngine.GetEntryScriptHash | Devuelve el hash del script del punto de entrada para el contrato inteligente. (el punto de inicio de la cadena de llamada del contrato) |

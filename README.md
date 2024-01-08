﻿## Project structure
- Controllers: classes derived from ``ControlerBase``, implementing API endpoints
    - ``PrimaryMissionController``: responsible for providing client-ready data related to the primary mission, provides the following GET-only SSE endpoints:
        - ``api/primary/temperature``
        - ``api/primary/pressure``
        - ``api/primary/altitude``
    - ``SecondaryMissionController``: responsible for providing client-ready data related to the secondary mission, provides the following GET-only SSE endpoints:
        - ``api/secondary/raw``
        - ``api/seconddary/ndvi``
    - ``GeneralController``: responsible for providing client-ready data which ins't related to any particular mission, provides the following GET-only SSE endpoints:
        - ``api/general/time``
        - ``api/general/acceleration``
        - ``api/general/position``
        - ``api/general/raw``
- Models: classes defining data models for the app to work with
    - ``DataStamp``: general information attached to all data sent, e.g., timestamp and coordinates
- Services: Modular classes implementing internal functionality
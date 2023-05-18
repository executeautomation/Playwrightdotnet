# Playwrightdotnet
Contains repository for playwright with .NET language binding


## Updates
The complete code is update to latest version of Playwright with latest version of .NET which is .NET 7


# Complete Video series on this repo in YouTube

https://www.youtube.com/playlist?list=PL6tu16kXT9PoUv6HwexX5LPBzzv7QkI9W

# Playwright Architecture

```mermaid
graph TB
  U["C#/Java/Python/TS SDK"] -- "Write Test" --> PT["Playwright Test"]
  PT -- "Uses" --> P["Playwright Driver"]
  P -- "Uses" --> C["Chromium"]
  P -- "Uses" --> F["Firefox"]
  P -- "Uses" --> S["Safari"]
  C -- "Controls" --> B["Browser"]
  B -- "Opens" --> Pc["Page Context"]
  B -- "Opens" --> Bc["Browser Context"]
  Pc -- "Interacts with" --> W["Web Page"]
  Bc -- "Opens" --> Ic["Incognito Web Page"]

  F -- "Controls" --> B["Browser"]
  B -- "Opens" --> Pc["Page Context"]
  B -- "Opens" --> Bc["Browser Context"]
  Pc -- "Interacts with" --> W["Web Page"]
  Bc -- "Opens" --> Ic["Incognito Web Page"]

  S -- "Controls" --> B["Browser"]
  B -- "Opens" --> Pc["Page Context"]
  B -- "Opens" --> Bc["Browser Context"]
  Pc -- "Interacts with" --> W["Web Page"]
  Bc -- "Opens" --> Ic["Incognito Web Page"]
  linkStyle 0 stroke:#2ecd71,stroke-width:2px;
  linkStyle 1 stroke:#2ecd71,stroke-width:2px;
  linkStyle 2 stroke:#2ecd71,stroke-width:2px;
  linkStyle 3 stroke:#2ecd71,stroke-width:2px;
  linkStyle 4 stroke:#2ecd71,stroke-width:2px;
  linkStyle 5 stroke:#2ecd71,stroke-width:2px;
  linkStyle 6 stroke:#2ecd71,stroke-width:2px;
  ```


# Playwrightdotnet
Contains a repository for `Playwright` with .NET language binding


## Updates
The complete code is updated to the latest version of Playwright with the latest version of .NET which is .NET 7


# Complete the Video series on this repo on YouTube

https://www.youtube.com/playlist?list=PL6tu16kXT9PoUv6HwexX5LPBzzv7QkI9W

# Udemy Course For Building an Advanced framework beyond the basics 🚀

https://www.udemy.com/course/framework-development-with-playwright-dotnet/ 🎉🦾

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


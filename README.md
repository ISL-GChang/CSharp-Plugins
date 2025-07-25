# CSharp-Plugins
Dynamo Graphs and Scripts for use with ISL Engineering workflows in Civil 3D and Revit.

# File Structure
## CSharp-Plugins Repo
The root folder contains C# plugins organized by feature category, with supporting files for deployment, documentation, and automation.

Plugin Organization Philosophy:

1. Group by Feature Domain (e.g., pipe_networks, alignment).

2. Each plugin/tool gets its own folder and project file.

All related automation scripts, CUI files, and documentation are kept at the root for clarity and maintainability.

```
CSharp-Plugins/
  ├─ src/
  │   ├─ pipe_networks/
  │   │   ├─ Plugin1/
  │   │   │   └─ Plugin1.csproj
  │   │   ├─ Plugin2/
  │   │   │   └─ Plugin2.csproj
  │   ├─ alignment/
  │   │   ├─ Plugin1/
  │   │   │   └─ Plugin1.csproj
  ├─ cui/
  │   ├─ Custom.cuix
  │   └─ Readme_CUI.md
  ├─ scripts/
  │   ├─ LoadPlugins.lsp
  │   └─ Readme_Scripts.md
  ├─ .github/
  │   └─ workflows/
  │        └─ build.yml
  ├─ docs/
  │   ├─ README.md
  │   ├─ BuildGuide.md
  │   └─ UserGuide.md
  ├─ release/
  │   └─ (DLLs, GitHub Release artifacts)

```

## Wiki
The Wiki contains user and developer documentation for each plugin and tool, organized by feature domain to match the repo’s directory structure.
Automation may update or link docs to project releases for up-to-date guidance.
```
CSharp-Plugins
  ├─ src/
  │   ├─ pipe_networks/
  │   │   ├─ Plugin1-README.md
  │   │   ├─ Plugin2-README.md
  │   ├─ alignment/
  │   │   ├─ Plugin1-README.md
  ├─ cui/
  │   └─ Custom.cuix-README.md
  ├─ scripts/
  │   └─ LoadPlugins.lsp-README.md

```

# Repo Structure


```
main ──── main ───── main ───────── main ──── main 
├─ hotfix ─┘ (bug fixes)└─ hotfix ─┘      │
│                                         │ (Release Notes)
└─ dev ─────────────── dev ──── dev ─┘
    ├─ feature/Plugin1 ─┘        │ 
    └─ feature/Plugin2 ──────────┘

```

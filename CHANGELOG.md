﻿# Changelog

All notable changes to this project will be documented in this file.

## [Unreleased]

- [Global] adding object-specific Service, and extension methods.

---

## [1.0.4] - 2025-02-16
### Modified
- rename Undo Limit to History Limit
- improve check way on TryUndo() and TryRedo() 
### Added
- Undo() and Redo() method to get state directly, throw exception on no state recovered
- set History Limit on building Local Service, default is History Limit on Project Setting, minimum limit is 4
### Fixed
- UndoCount returning -1 on no state history.

## [1.0.3] - 2025-02-14
- Experimental Released.   
  For detail please visit and bookmark our [GitBook](https://aceland-workshop.gitbook.io/aceland-unity-packages/)
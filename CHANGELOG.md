# Changelog

All notable changes to this project will be documented in this file.

## [Unreleased]

---

## [1.0.10] - 2025-02-27
### Modified
- work with MementoState and GlobalMementoState
- default Clone method is System.Object.MemberwiseClone()
### Fixed
- Unity Object is not supporting issue 

## [1.0.9] - 2025-02-26
### Fixed
- [Local Service] Caretaker not undo first memento state
### Modified
- [Local Service] Improved Caretaker TryUndo and TryRedo code.

## [1.0.8] - 2025-02-24
### Added
- [Global Service] Add more states to GlobalMementoState

## [1.0.7] - 2025-02-24
### Modified
- [Global Service] separate OnStateChanged to OnStateUndo and OnStateRedo

## [1.0.6] - 2025-02-23
### Modified
- [Global Service] save customized global memento states

## [1.0.5] - 2025-02-23
### Modified
- change dependencies - Deep Clone supports Unity data type

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
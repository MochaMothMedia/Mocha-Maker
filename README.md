# Mocha-Maker
A set of tools and editors for making 3D games in Monogame.

# Projects
This system is broken up into multiple different projects that serve specific purposes.

## Core
The Core project is a highly abstract set of definitions the form the shape of the system. All projects with concrete implementation details will depend on the core.

## Avalonia Launcher
The main entry point to the system. Generally, the Launcher will depend on the Core and all other systems and use dependency injection to pass in all of the concrete implementations.

This implementation is using [Avalonia](https://docs.avaloniaui.net/) as a base for drawing the UI.

## Avalonia UI
Avalonia bindings for Core UI elements.

## Project Manager
UI Tie-ins for the Project Manager page.

## Editor
The main view of the editor tools. This is where we define the layout of all panels and provide access to move them around, show and hide panels, and save the layout for re-use.

## Entity Orchestrator
The panels that allow creating and editing the entities in a scene. This includes the hierarchy panel, the asset panel, and the properties panel.

## Entity Viewer
The 3D view of the entities currently loaded.

## Prefab Manager
A panel that lets us see our prefabs and select them for editing.

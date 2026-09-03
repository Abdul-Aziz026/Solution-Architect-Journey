# Claude Code Project Configuration

## Overview
This project is configured for Claude Code development with custom skills and agents.

## Project Structure

- **skills/** - Custom skill definitions for reusable task automation
- **agents/** - Custom agent configurations for specialized workflows
- **settings.json** - Project-wide Claude Code settings and preferences
- **settings.local.json** - Local overrides (git-ignored)
- **.mcp.json** - MCP server integrations
- **CLAUDE.md** - This file - project documentation

## Getting Started

1. Review `settings.json` for project-wide configurations
2. Add custom agents in the `agents/` directory
3. Define reusable skills in the `skills/` directory
4. Configure MCP servers in `.mcp.json`

## Documentation

- For Claude Code CLI features: [Claude Code Documentation](https://claude.ai/claude-code)
- For API reference: See `claude-api` skill
- For custom agents: Refer to Agent SDK documentation

## Custom Skills

Add skill files here with frontmatter:
```markdown
---
name: skill-name
description: Brief description
---

Your skill instructions here
```

## Custom Agents

Create agent definitions in `agents/` for specialized tasks.

## Notes

- All files in this directory are tracked by git except `*.local.json` and `*.local.md`
- Use `settings.local.json` for sensitive or environment-specific configurations
- MCP servers extend Claude's capabilities with external integrations

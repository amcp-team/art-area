# Contribution Guidelines

This document describes how developers should contribute to our projects. First of all these rules are for the core team, but if you wish to take part in development than you should read rules carefully and follow them.

## How we develop projects?

1. :thinking: **Idea** is the first thing to do. In our team, we share ideas of projects and then decide whether we will develop them or not
1. :bar_chart: **Discussion** help us provide enough information about the project for each other, brainstorm it carefully and come up with the clear vision of it
1. :pencil: **Technical Task** is the last thing we do before actual development. As we make it iteratively than technical task describes only features of the next version of the project
1. :computer: **Development** is started from transporting Technical Task to GitHub issues on the project repository and bounding them to Milestone of the upcoming version
1. :heavy_exclamation_mark: **Changes are made only in non-master branches**. When one wants to develop something (new feature or remove bug) then one should create a new branch (see branch naming rules in style guide section below) or choose an existing one. No code changes are committed directly to _master_ or _release_ branches. The _release_ branch is fully free of direct changes and _master_ can have some project management changes
1. :beetle: **Testing and bug fixing** is must-do operation before each release
1. :thumbsup: **Release**!!!
1. :arrows_counterclockwise: Go to the technical task step until the project is finished

## Contributing

### Making Ideal Bug Report

If you found a bug or some unexpected behavior, please follow the steps below:

1. :mag_right: Check if this is a new bug by visiting project issues and looking through one marked with `bug` label
2. :loudspeaker: Create a new issue and fill it according to _Bug Report_ issue template
3. :hourglass: Track for bug and comment on issue thread if you find anything that can help to deal with it

When writing Bug Report please remember to provide _full_ and _clear_ description of everything that can help with debugging and be ready to answer questions specifying questions from developers and further edits to issue message.

### Making Ideal Feature Request

Feature Request that is made by team members should be first privately discussed and then published in project issues. When asking for a new feature please follow these steps:

1. Check if your idea is not already described in issues of the project (or maybe something close to our idea)
2. If so then write to the thread and provide your vision
3. Else create a new issue based on Feature Request template

When writing Feature Request (even if you are going to develop it) be patient and provide an accurate description of wished changes and new functionality in order to help other developers get it better. Be ready to answer comments of other developers and discuss the issue further.

## Styleguide 

To develop projects effectively this strict style guide is provided.

### C# Styleguide

- Use **PascalCase** for:
  - Classes and interfaces (interfaces should have `I` prefix as general C# code convention suggests)
  - Methods
  - Static Fields
  - Delegates
    - with `EventHandler` suffix for delegates that are used in events
    - with `Callback` suffix for delegates that are used as events
  - Events with `On` prefix
- Use **camelCase** for fields (even public one) and local variables and method arguments, if they overlap class fields than use this.
- Each **brace** should be on it's **own line**
- Use **tabs** for lining text
- Do not make lines with more than 100 characters
- Write summaries with `///` for classes and methods
- Fields should be provided with one line comment
- One line does one thing
- Provide with comments only **blocks of code** not lines
- **Align comments** for fields
- When declaring classes **write separate regions** for fields and methods
- **Never use all caps**

### Git Commit Messages
- Use the present tense ("Add feature" not "Added feature")
- Use the imperative mood ("Move the cursor to..." not "Moves the cursor to...")
- Limit the first line to 72 characters or less
- Reference issues and pull requests liberally after the first line

### Branch Naming

When a branch is needed think of its purpose and use one of the following templates for branch name:

| **Branch Name Template** | **Purpose** |
| --- | --- |
| `feature/branch-name` | This branch is made for adding NEW things to the project |
| `enhancement/branch-name` | This branch is made for improving already existing features |
| `reimagine/branch-name` | This branch is made for re-implementing some already existing features |
| `debug/branch-name` | This branch is made for removing critical logic mistakes of the project |

Also, there are some special branches for different purposes

- `master` - Is for storing in-development project versions and making some non-code edits
- `refactor` - Is for analyzing and improving code
- `release` - Stores only release versions of the project

### Issue and Pull Request Labels

To quickly describe state and category of issue or pull request use the following labels

**Issue State Labels**

| **Label name** | **Description** |
| --- | --- |
| `enhancement` | Feature requests |
| `bug` | Confirmed bugs or reports that are very likely to be bugs |
| `question` | This issue needs some discussion |
| `help-wanted` | Developer is stuck and waits for help |
| `blocked` | Cannot be resolved because of some other issues and pull requests |


**Pull Request State Labels**

| **Label name** | **Description** |
| --- | --- |
| `work-in-progress` | Pull requests which are still being worked on, more changes will follow |
| `needs-reviews` | Code review is needed |
| `requires-changes` | Needs to be updated according to review |

**Category Labels**

| **Label name** | **Description** |
| --- | --- |
| `urgent` | Should be resolved as quickly as possible |
| `important` | Key issue |
| `challenge` | A steep climb, not a long walk |
| `performance` | Related to project performance |
| `analysis` | Related to problem domain |
| `experimental` | Research in terms of project |

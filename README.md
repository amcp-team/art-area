# ArtArea

[![Join the chat at https://gitter.im/art-area/community](https://badges.gitter.im/art-area/community.svg)](https://gitter.im/art-area/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

> Currently readme works as a project description for PL project description, but worth mentioning, that it's not only for university, but also for our team personal work out

Service for source control and management of digital art projects

## Problem

Modern development of visual art lacks structure and automation. We see following problems:
- managers (or clients) are usually loosly coupled with designers & artists and they don't have general tool for sharing ideas, tasks & discussing them - Pinterest/Behance/ArtStation for inspiration, Google Docs/Drive/Email for sharing tasks & dis. docs, many different tools that make it easy to loose or miss something
- designers often lack structure in developemnt - they simulataneously store many different source files of the same task, call them stuipidly & mismatch them when send for review, which slows development process down

## Solution

_Art Area_ - service for management & source control. (Most close service of the same type is GitHub) 

We provide: 
- _Web Client_ which is mainly for managers

   For example one can work in Ubisoft as a game-designer. GD got an idea of the game, which was supported by the direction of the company & now one has to start brainstorming & creating consepts with one's new team of designers & artists. For this new project one creates a new private Project on our service which can be than used on any stage of game development. 
   
   Inside project GD creates _Art Boards_ - special containers for art dedicated to some separated task. For example as on is only starting project one needs a design for main charater - old pirate. GD creates an Art Board where one describes this character, attaches references, assignes designers, puts tags, etc. In this way Art Board is a mix of task, discussion & storage for solution version.
   
   After that assigned designer procced to Desktop Client where they initialize project on their PC. Client defines file structure associated with project structure in our service & handels simple back-up like versioning. During the development at any moment artist can submit new version of file - _Pin_, attach thumbnail and message to it. If designer sees, that previous Pin of consept was better one can always switch to it using desktop client. Worth mentioning, that it's possible to submit Pins using web client.
   
   When designer finds that it's there is good Pin (or collection of pins) one can send a Review Request to other user (or group of users). Review Request can be either approved or disapproved (with Edit Request). Review Request is not required actually - users still can comment Pin & possibly mark bad and good results on a thumbnail image.
   
   After this kind of iterative work manager can mark Art Board as finished, mark some Pins as solution-one, delete everything (which we do not support) one finds odd & meaningless.
   
- _Desktop Client_

   In desktop client designer (as it's main target-users are artists) clones Project and Art Board he is intersted in (and able to - security and administrating :lock:). In this way one will have a folder in file system with Project name and inner folder with Art Board name where one should create a source file (for example `.psd` file) which will be registered by the system. Than after some work user can submit a new Pin which (as it was already mentioned) is a combination of a source file, thumbnail (small image that describes work done) & message.
   
   It is important that pins are actually grouped by source files in sequences if one wasn't changing a source file name on a client which we do not support too. In this way we not only have different versions & ideas for the file, we have it's history.
   
   In desktop client user can submit new pins, get pins of other users, load new Art Boards and delete existing one locally.
   
### Implementation Notes

We will use mainly powerful .NET Core 3.0 platform:

- Web Client
   - ASP.NET Core (C#) - OOP
   - Angular (TypeScript) - Declarative
- Desktop
   - Web API (F#) - Functional
   - WPF (C#) - OOP
- MongoDB as Database

More details about used technologies & frameworks will be provided in appropriate readmes of projects

### Features

> We should note that this project is developed not only for FLS Hackathon & PL Pass Project, but also as a global challenge for our team, so current list of features is not what we want to develop for concrete point of time, but what we want to see in our MVP+ project version (commercial-ready MVP). Currently we can't say what we will develop (also because we don't know time limits established)
> Also though this feature-task list looks massive and full it's not


#### Web Client:

- [ ] User
   - [ ] Sing In
   - [ ] Sign out
   - [ ] Identity-like user validation
   - [ ] Editing user data (name, username, password, avatar)
   - [ ] User Dashboard Profiling
- [ ] Project Creation
   - [ ] Simple static fields
   - [ ] Privacy settings
   - [ ] Cold-start collaborators and roles
- [ ] Project Editing (basic data)
- [ ] Project Management
   - [ ] Project Deletion/Closing
   - [ ] Add/Remove/Edit role of collaborator
   - [ ] Change privacy of project (private, public)
- [ ] Art Board functinality
   - [ ] Create Art Boards
      - [ ] Basic Data
      - [ ] Assigned collaborators 
      - [ ] Privacy settings (private, locked, public)
      - [ ] Desing Document
         - [ ] (*) Intgration with Pinterest for auto-loading of references
         - [ ] (*) Custom file attachments
         - [ ] (*) Thumbnail images (`.png`/`.jpeg`/`.gif`) attacments & display
      - [ ] (*) Tags (=> tag management inside Art Board/Project)
   - [ ] Delete Art Board
   - [ ] Edit Art Board Data
      - [ ] Name + Desciption + DD
      - [ ] Privacy settings
      - [ ] Assignees
- [ ] Pin Functionality
   - [ ] Create New Pin via special form
   - [ ] Comment a Pin (possibly comment concrete point on a pin) + Delete, Edit comment
   - [ ] Approve/Disapprove Pin
   - [ ] Download Pin Source Code
   - [ ] Manage Pin accessibility (private, locked, public)
   - [ ] Group Pin by source files => create Pin history (works for source files with the same name)
   
#### Desktop Client
   
   - [ ] Sign In
   - [ ] Clone Project 
   - [ ] Clone Art Board => establish Project structure further in some folder
   - [ ] Post new Pin
   - [ ] Show other pins
   - [ ] Download source files & change local source files with remote ones
   
   


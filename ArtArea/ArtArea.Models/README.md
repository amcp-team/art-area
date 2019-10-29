### ArtArea.Models

**Project Type:** Class Library

**Technology**: .NET Core 3.0

**Language**: C#

**Programming Paradigm**: Object-Oriented

### Project Task

Defines general models for our project (raw data stored in MongoDB). There we store only raw models.

Models:

**User**

|  Property Name  |  Type  | Note  |
|---|---|---|
| Id | string | Should be marked ObjectId in Mongo |
| Username | string | Unique for each user |
| Password | string | Regexed |
| Email | string | Regexed |
| Name | string | Optional |


**Project**

|  Property Name  |  Type  | Note  |
|---|---|---|
| Id | string | Should be marker ObjectId in Mongo |
| Name | string | Unique in combination with username, editable |
| Description | string | Editable |
| Owner | string | ObjectId of user |
| Contributors | List<string> | List of stringed ObjectIds of user that are contributors of the project  |
  
**Art Board**

|  Property Name  |  Type  | Note  |
|---|---|---|
| Id | int | Unique number for Art Board inside project id |
| ProjectId | string | Id of hosting project, in combination with project id we get unique id for Art Board |



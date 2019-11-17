## ArtArea.Api

Web API for desktop client developed with F# & Giraffe framework

### Endpoints

GET -> project/{projectId} : returns short data about project (sends userdata in cookies)
GET -> board/{boardId} : return short data about board
GET -> user/{user} : return user data based on name or id (we should check if we passed name or id - better only id)
GET -> pin/{pinId} : get pin data by id {source file, thumbnail & message}
GET -> pingroup/{groupId} : get pin group data

POST -> pin/ {application/json pin object} -> send new pin object & return it's id in db (possibly)
        actually it sends a bit more complex file that configures how we should process new pin & where to store it

PUT -> 

DELETE
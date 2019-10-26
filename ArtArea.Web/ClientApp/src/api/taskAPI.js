export function getTask(){
    const result = {
        name: "BluePirote",
        description: "It's blue and angry",
        slides: [{path:"https://via.placeholder.com/200", name:"PiratV1", id:"42"}, {path:"https://via.placeholder.com/200", name:"PiratV1", id: "43"}]
    }
    return Promise.resolve(result)
}
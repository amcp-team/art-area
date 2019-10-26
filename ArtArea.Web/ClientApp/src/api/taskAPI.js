export async function getTask(){
    const res = await fetch('/api/task', {
        method: 'GET'
    });

    if (res.status !== 200) {
        return null;
    }

    const data = await res.json();


    // {
    //     name: "BluePirote",
    //     description: "It's blue and angry",
    //     slides: [{path:"https://via.placeholder.com/200", name:"PiratV1", id:"42"}, {path:"https://via.placeholder.com/200", //name:"PiratV1", id: "43"}]
    // }
    return data;
}
export async function getComments()
{
    const res = await fetch('/api/task/comments', {
        method: 'GET'
    });

    if (res.status !== 200) {
        return null;
    }

    const data = await res.json();

    return data;

}
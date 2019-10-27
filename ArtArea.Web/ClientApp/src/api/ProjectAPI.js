export async function getIssues()
{
    const res = await fetch('api/project/');

    if (res.status !== 200) {
        return null;
    }

    const data = await res.json();

    return data;
}

export async function addIssue(issue)
{
    const res = await fetch('api/project/', {
        method: "POST",
        body: JSON.stringify(issue),
        headers: new Headers({"content-type" : "application/json"})
    });

    if(res.status !== 200)
        return null;
    console.log(res);
    return res;
}
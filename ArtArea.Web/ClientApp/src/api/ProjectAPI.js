export async function getIssues()
{
    const res = await fetch('api/project/');

    if (res.status !== 200) {
        return null;
    }

    const data = await res.json();

    return data;
}
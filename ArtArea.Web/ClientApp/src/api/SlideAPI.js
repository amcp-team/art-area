export async function getSlide(id){
    const res = await fetch('api/file/'+id+'/thumbdata')

    if (res.status !== 200) {
        return null;
    }

    const data = await res.json();

    return data;
}

export async function getComment(id)
{
    const res = await fetch('api/file/'+id+'/comments');

    if (res.status !== 200) {
        return null;
    }

    const data = await res.json();

    return data;
}

export async function addComment(newComment){
    await fetch('api/file/'+newComment.fileId+'/comment', {
        method: 'POST',
        body: JSON.stringify(newComment),
        headers: new Headers({'content-type': 'application/json'})
    })
}
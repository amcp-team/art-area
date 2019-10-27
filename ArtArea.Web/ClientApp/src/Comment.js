import React from "react"

export class Comment extends React.Component{
    state={
        name: "",
        text: ""
    }

    onNameChange=(event)=>{
        this.setState({name: event.target.value})
    }

    onTextCommentChange=(event)=>{
        this.setState({text: event.target.value})
    }

    addComment=(event)=>{
        this.props.addComment({...this.state, fileId:this.props.fileId})
        .then(() => {
            this.setState({name:"",text:""})})
            
        
    }

    render(){
        return(
            <>
             <div class="media">      
                        <div class="media-body">
                            {this.props.comment.map((data)=>
                                (<div class="media">
                                    <div class="media-body">
                                        <h5 class="mt-0">{data.name}</h5>
                                        {data.text}
                                    </div>
                                
                                </div>)            
                            )}                            
                        </div>      
                    </div> 
                    <div className="form-group">
                        <input onInput={this.onNameChange} type="email" className="form-control form-group" value={this.state.name} id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Name"/>

                        <textarea onInput={this.onTextCommentChange} className="form-control form-group" value={this.state.text} aria-label="With textarea"></textarea>
                        <button type="button" onClick={this.addComment}  className="btn btn-primary form-group">Send comment</button>
                    </div> 
            </>
        )         
    }  
}

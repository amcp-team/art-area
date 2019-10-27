import React from "react"
import{Link} from "react-router-dom"

export class NewIshue extends React.Component{
    state={
        name:"",
        desription:"",
    }

    

    render(){
        console.log(this.state)
        return(
            <>
            <div className="row">
                <div className="col-12">
                    <div className="form-group my-5">
                        <input onInput={this.onNameChange} type="email" className="form-control form-group" placeholder="Name of Ishue"/>

                        <textarea onInput={this.onTextCommentChange} className="form-control form-group"  aria-label="With textarea" placeholder="Enter description"></textarea>
                        <a href="/issue/:id" class="btn btn-primary" role="button">Create Issue</a>
                    </div> 
                </div>

            </div>
            
            </>
        )
    }
}



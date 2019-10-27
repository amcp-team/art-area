import React from "react"
import{Link} from "react-router-dom"
import propTypes from "prop-types"
import {addIssue} from './api/ProjectAPI'
import history from 'history'
import { getHistory } from "./History"

export class NewIshue extends React.Component{

    static contextType = {
        history: propTypes.object,
    }

    state={
        name:"",
        description:"",
    }

    onNameChange=(event)=>{
        this.setState({name: event.target.value})
    }

    onTextCommentChange=(event)=>{
        this.setState({description: event.target.value})
    }

    addIssue=()=>{
        addIssue(this.state)
        .then(response => 
            {
                let id = response.url.split("issue/").pop();
                console.log(id);
                getHistory().push("issue/" + id)
                // this.context.history.push("issue/" + id);
            })
    }

    render(){
        console.log(this.state)
        return(
            <>
            <div className="row">
                <div className="col-12 ">
                    <div className="jumbotron text-white Header">
                        <h1 className="display-4">Create New Issue</h1>
                    </div>
                </div>         
            </div>
            
            <div className="row">
                <div className="col-12">
                    <div className="form-group">
                        <p>
                            <label><h3>Name</h3></label>
                            <input onInput={this.onNameChange} type="email" className="form-control form-group" placeholder="Name of Ishue"/>
                        </p>
                        <p>
                            <label><h3>Description</h3></label>
                            <textarea onInput={this.onTextCommentChange} className="form-control form-group SizeText"  aria-label="With textarea" placeholder="Enter description"></textarea>
                        </p>
                        <div class="bg-dark Lin ml-5 mr-5 mt-4"><button class="btn btn-dark text-white " onClick={this.addIssue}>CREATE NEW</button></div>
                    </div> 
                </div>

            </div>
            
            </>
        )
    }
}



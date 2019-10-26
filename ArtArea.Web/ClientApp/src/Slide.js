import React from "react"
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
  } from "react-router-dom";
import { getSlide,addComment,getComment } from "./api/SlideAPI";
import {Comment} from "./Comment.js"



export class Slide extends React.Component{
    state={
        slide:{},
        comments:[]
    }

    componentDidMount(){
        getSlide(this.props.match.params.id)
        .then((data)=>{
            console.log(data)
            this.setState({slide: data})

            this.getComments()
        })

        
    }

    getComments(){
        getComment(this.props.match.params.id)
        .then((data)=>{
            console.log(data)
            this.setState({comments:data})
        })
    }

    addComment=(newComment)=>{
        return addComment(newComment).then(()=>{
            this.getComments()
        }
        )
    }

    render(){
        console.log("111", this.props, this.state) 
        return (<>
            <div className="row">
                <div className="col-8 my-4">
                <Link to="/">Home page</Link>
                <div style={{width: 600,height: 600}} class="img-thumbnail d-flex align-items-center justify-content-center bg-light">
                <img src={"data:"+this.state.slide.fileType+";base64, "+this.state.slide.base64} class="img-thumbnail img-fluid"/>
            </div>
                </div>              
                
                <div className="col-4 my-4">
                    <Comment comment={this.state.comments} addComment={this.addComment} fileId={this.props.match.params.id}/>                
                </div>
                

            </div>
            </>
        )
    }
}





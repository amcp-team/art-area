import React from "react"
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
  } from "react-router-dom";
import { getSlide,addComment } from "./api/SlideAPI";
import { getSlideComment } from "./api/GetSlideComment";
import {Comment} from "./Comment.js"


export class Slide extends React.Component{
    state={
        slide:{},
        comment:[]
    }

    componentDidMount(){
        getSlide()
        .then((data)=>{
            console.log(data)
            this.setState({slide: data})

            this.getComments()
        })

        
    }

    getComments(){
        getSlideComment()
        .then((data)=>{
            console.log(data)
            this.setState({comment:data})
        })
    }

    addComment=(newComment)=>{
        addComment(newComment).then(()=>{
            this.getComments()
        }
        )
    }

    render(){
        console.log(this.props) 
        return (<>
            <div className="row">
                <div className="col-5">
                    <img src={"data:"+this.state.slide.fileType+";base64, "+this.state.slide.base64} class="img-thumbnail"/>
                </div>              
                
                <div className="col-7">
                    <Comment comment={this.state.comment} addComment={this.addComment}/>                
                </div>
                
                

            </div>
            </>
        )
    }
}





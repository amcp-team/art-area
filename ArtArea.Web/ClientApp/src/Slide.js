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
        comment:[]
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
        console.log("111", this.props, this.state) 
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





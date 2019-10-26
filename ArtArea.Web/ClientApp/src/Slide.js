import React from "react"
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
  } from "react-router-dom";
import { getSlide } from "./api/SlideAPI";
import { getSlideComment } from "./api/GetSlideComment";
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

        })

        getSlideComment()
        .then((data)=>{
            console.log(data)
            this.setState({comment:data})
        })
    }

    

    render(){
        console.log(this.props) 
        return (<>
            <div className="row">
                <div className="col-5">
                    <img src={"data:"+this.state.slide.fileType+";base64, "+this.state.slide.base64} class="img-thumbnail"/>
                </div>
                

                
                <div className="col-7">
                    <div class="media">
      
                        <div class="media-body">
                            {this.state.comment.map((data)=>{
                                return(<div class="media">
                                    <div class="media-body">
                            <h5 class="mt-0">Media heading</h5>
                            Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis. Fusce condimentum nunc ac nisi vulputate fringilla. Donec lacinia congue felis in faucibus.
                        </div>
                                </div>)
                            }

                            )}
                            <h5 class="mt-0">Media heading</h5>
                            Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis. Fusce condimentum nunc ac nisi vulputate fringilla. Donec lacinia congue felis in faucibus.
                        </div>
      
                    </div>
                    <div class="media">
      
                        <div class="media-body">
                            <h5 class="mt-0">Media heading</h5>
                            Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis. Fusce condimentum nunc ac nisi vulputate fringilla. Donec lacinia congue felis in faucibus.
                        </div>
      
                    </div>
                    <div class="media">
      
                        <div class="media-body">
                            <h5 class="mt-0">Media heading</h5>
                            Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis. Fusce condimentum nunc ac nisi vulputate fringilla. Donec lacinia congue felis in faucibus.
                        </div>
      
                    </div>
                </div>
                
                

            </div>
            </>
        )
    }
}





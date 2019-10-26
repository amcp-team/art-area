import React from "react"

import { getTask } from "./api/taskAPI"
export class Task extends React.Component{

    state={
        name:"",
        description:"",
        slides:[]

    }
    componentDidMount(){
        getTask()
        .then((data)=>{
            console.log(data)
            this.setState(data)

        })
    }
    render(){
        return (
        <>
        <div class="row">
          <div class="col-12 ">
            <div class="jumbotron">
              <h1 class="display-4">{this.state.name}</h1>
              <p class="lead">{this.state.description}</p>              
            </div>
          </div>         
        </div>

        <div class="row">
          <div class="col-12">
            {this.state.slides.map((slide)=>{
                return(<a href={"/slide/"+slide.id}><img src={slide.path}/></a>)
            })}           
          </div>
        </div>

        <div class="row">
          <div class="col-12">
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


            <div class="media">     
              <div class="media-body">
                <h5 class="mt-0">Media heading</h5>
                Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis. Fusce condimentum nunc ac nisi vulputate fringilla. Donec lacinia congue felis in faucibus.
              </div>             
            </div>
          <div/>
        </div>
      </div></>
        )
    }
}
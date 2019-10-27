import React from "react"
import { getTask, getComments } from "./api/taskAPI"
import{Link} from "react-router-dom"
import {Picture} from "./Picture"
export class Task extends React.Component{

    constructor(props){
      super(props)
      this.inputRef = React.createRef();
    }
    state={
        name:"",
        description:"",
        slides:[],
        comments:[]
    }
    componentDidMount(){
        getTask(this.props.match.params.id)
        .then((data)=>{
            console.log(data)
            this.setState(data)
          })
          
          getComments(this.props.match.params.id)
          .then((data) => {
            console.log(data)
            let newstate = this.state;
            newstate.comments = data;
            this.setState(data)
        })

        
    }

    

    handleFileUpload = () =>
    {
      const form = new FormData();
      if(!this.inputRef.current.files.length)
      return;
      
      const [file] = this.inputRef.current.files;
      
      form.append("myfile", file);

      fetch("/api/file/"+this.props.match.params.id, {
        method: "POST",
        body: form
      }).then(() => 
      {
        getTask(this.props.match.params.id)
        .then((data)=>{
          console.log(data)
          this.setState(data)
        })
      });

      this.inputRef.current.value=""

      // console.log("111", this.inputRef.files);
    }
    render(){
      console.log(this.state)
      return (
        <>
        <div className="row">
          <div className="col-12 ">
            <div className="jumbotron">
              <h1 className="display-4">{this.state.name}</h1>
              <p className="lead">{this.state.description}</p>              
            </div>
          </div>         
        </div>

        <Link to={"/"}>Home</Link>

        <div className="row">
          <div className="col-12">
            <div className="d-flex justify-content-around flex-wrap">
              {this.state.slides.map((slide)=>{
                  return(<Link to={"/slide/"+slide.id} key={slide.id}><Picture src={"data:"+slide.fileType+";base64, "+slide.base64}/></Link>)
              })}
            </div>           
          </div>
        </div>
        <div className="row my-3 mb-5">
          <div className="col-12 form-inline border-0">
           <input type="file" className="form-control mr-3 mb-1 ml-2" ref={this.inputRef}/>
           <button type="button" class="btn btn-secondary" onClick={this.handleFileUpload}>Upload File</button>
          </div>
        </div>

        <div class="row">
          <div class="col-12">
            {this.state.comments.map((comment) => {
              return(
                <div class="media">
                  <div class="media-body">                    
                    <h5 class="mt-0">{comment.name}<small class="ml-2">{comment.date}</small></h5>
                    {comment.text} 
                    
                  </div>  
                </div>
            )})}
          <div/>
        </div>
      </div></>
        )
    }
}
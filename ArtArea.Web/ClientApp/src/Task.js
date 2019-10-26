import React from "react"
import { getTask, getComments } from "./api/taskAPI"
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
        getTask()
        .then((data)=>{
            console.log(data)
            this.setState(data)
          })
          
          getComments()
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

      fetch("/api/file/", {
        method: "POST",
        body: form
      });
      
      getTask()
      .then((data)=>{
          console.log(data)
          this.setState(data)
        })

      // console.log("111", this.inputRef.files);
    }
    render(){
      console.log(this.state)
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
                return(<a href={"/slide/"+slide.id} key={slide.id}><img src={"data:"+slide.fileType+";base64, "+slide.base64}/></a>)
            })}           
          </div>
        </div>
        <div class="row">
          <input type="file" id="uploadThumbnail" ref={this.inputRef}/>
          <button type="button" onClick={this.handleFileUpload}>Upload File</button>
        </div>

        <div class="row">
          <div class="col-12">
            {this.state.comments.map((comment) => {
              return(
                <div class="media">
                  <div class="media-body">
                    <h5 class="mt-0">{comment.name}</h5>
                    {comment.text} <br/>
                    {comment.date}
                  </div>  
                </div>
            )})}
          <div/>
        </div>
      </div></>
        )
    }
}
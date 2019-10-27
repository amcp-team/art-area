import React from "react"
import{Link} from "react-router-dom"
import {getIssues} from './api/ProjectAPI'
export class Project extends React.Component{
    state={
        issues: []
    }

    componentDidMount(){
        getIssues()
        .then((data) => {
            console.log(data)
            this.setState(data)
        })
    }

    render()
    {
        console.log(111,this.state)

        return(
            <>
            
            <div className="row">
                <div className="col-12 ">
                    <div className="jumbotron text-white Header ml-3">
                        <h1 className="display-4y">Art Area Design</h1>
                        <p className="lead">Project for developing design of Art Area service</p>              
                    </div>
                </div>         
            </div>
            

            <div className="row text-dark">
                <div className="col-4">
                    <h1 class="ml-5">Your issues</h1>
                </div>
                <div className="col-5"></div>
                <div className="col-3">
                    {<div class="bg-dark Lin mr-5 mt-1"><Link to={"/create"} className="text-white L btn btn-link">Create new isshue</Link></div>           }
                </div>
                
            </div>

            <div className="row my-4">
                <div className="col-12">
                    <ul className="list-group list-group-flush">
                    
                        {this.state.issues.map((issue)=>{
                            return(
                                    <li class="list-group-item" key={issue.id}>
                                <Link to={"/issue/"+issue.id}  className="L">
                                        <div class="card border-light">
                                    <h5 class="card-title pt-4 pl-4 text-dark">{issue.name}</h5>
                                    <p class="card-text pl-4 pb-4 text-dark">{issue.description}</p>
                                </div>
                            </Link>
                                </li>
                            )
                        })}
                    
                    </ul>          
                </div>
            </div>
            
            </>
        )
    }
}
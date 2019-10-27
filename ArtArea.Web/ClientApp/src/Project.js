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
            <div className="row-fluid">
                <div className="col-12 ">
                    <div className="jumbotron Header">
                        <h1 className="display-4y">Art Area Design</h1>
                        <p className="lead">Project for developing design of Art Area service</p>              
                    </div>
                </div>         
            </div>

            <div className="row">
                <div className="col-4">
                    <h1 class="ml-3">Your isshues</h1>
                </div>
                <div className="col-6"></div>
                <div className="col-2">
                    <Link to={"/create"}>Create new isshue</Link>            
                </div>
            </div>

            <div className="row my-4">
                <div className="col-12">
                    <ul className="list-group list-group-flush">
                    <li class="list-group-item">
                        {this.state.issues.map((issue)=>{
                            return(<Link to={"/issue/"+issue.id} key={issue.id}>
                                <div class="card">
                                    <h5 class="card-title pt-4 pl-4 ">{issue.name}</h5>
                                    <p class="card-text pl-4 pb-4 ">{issue.description}</p>
                                </div>
                            </Link>)
                        })}
                    </li>
                    </ul>          
                </div>
            </div>
            
            </>
        )
    }
}
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
                    <div className="jumbotron">
                        <h1 className="display-4">Art Area Design</h1>
                        <p className="lead">Project for developing design of Art Area service</p>              
                    </div>
                </div>         
            </div>

            <div className="row">
                <div className="col-12">
                    <div className="d-flex justify-content-around flex-wrap">
                        {this.state.issues.map((issue)=>{
                            return(<Link to={"/issue/"+issue.id} key={issue.id}>
                                <div class="card">
                                    <h5 class="card-title">{issue.name}</h5>
                                    <p class="card-text">{issue.description}</p>
                                </div>
                            </Link>)
                        })}
                    </div>           
                </div>
            </div>
            <Link to={"/create"}>Create new isshue
            </Link>
            </>
        )
    }
}
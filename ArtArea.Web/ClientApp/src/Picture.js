import React from "react"

export class Picture extends React.Component{
    render(){
        return(
            <div style={{width: 200,height: 200}} class="img-thumbnail d-flex align-items-center justify-content-center mb-4  ">
                <img src={this.props.src} style={{maxWidth:"100%",objectFit: "center"}}/>
            </div>
        )
    }
}
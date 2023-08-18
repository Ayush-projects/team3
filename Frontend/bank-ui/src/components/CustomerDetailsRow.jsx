import React, { Component } from 'react';
import styled from 'styled-components';



class CustomerDetailsRow extends Component {
    
render() {
    return (

        <div class="container" style={{color:"black"}}>
	    <div class="col-md-12">
    	<div class="panel panel-default">
				
        <div class="panel-body">
            <br></br>
            <table class="table table-condensed table-striped">
            <thead>
                <tr>
                        <th></th>
                            <th>TRANSACTION ID</th>
                            <th>TIME</th>
                            <th>TYPE</th>
                            <th> AMOUNT</th>
                            <th>STATUS</th>
                            <th></th>
                            
                
                </tr>
            </thead>

            <tbody>
                <tr data-toggle="collapse" data-target="#demo1" class="accordion-toggle">
                <td></td>
                <td>123</td>
                    <td>12:30 PM</td>
                    <td> Withdrawal</td>
                    <td> 2000</td>
                    <td> Success</td>
                    <td></td>
                </tr>
                
            
                    
                <tr data-toggle="collapse" data-target="#demo2" class="accordion-toggle">
                    <td></td>
                    <td>123</td>
                    <td>12:30 PM</td>
                    <td> Withdrawal</td>
                    <td> 2000</td>
                    <td> Success</td>
                    <td></td>
                </tr>
                
                <tr data-toggle="collapse" data-target="#demo3" class="accordion-toggle">
                    <td></td>
                    <td>123</td>
                    <td>12:30 PM</td>
                    <td> Withdrawal</td>
                    <td> 2000</td>
                    <td> Success</td>
                    <td></td>
                </tr>
            
            </tbody>    
            </table>
            </div>
        
        </div> 
        
        </div>
	    </div>
    );
    }
  }
  
  export default CustomerDetailsRow;

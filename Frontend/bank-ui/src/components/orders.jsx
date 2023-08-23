import React, {useState, useEffect} from 'react';
import DashboardHeader from './DashboardHeader';


import {calculateRange, sliceData} from '../utils/table-pagination';

import '../styles/styles.css';
import DoneIcon from '../assets/icons/done.svg';
import CancelIcon from '../assets/icons/cancel.svg';
import RefundedIcon from '../assets/icons/refunded.svg';
import { NotificationManager } from 'react-notifications';
import axios from 'axios'
function Orders () {
  
    const [orders, setOrders] = useState('');
    const [all_trans, set_all_trans] =  useState('')
   const [test, setTest] = useState('')
    useEffect(() => {
   let token = localStorage.getItem("token")
      axios.get("https://localhost:5000/api/Transaction/GetLast10Transactions", {
        headers: {
        
            'Authorization': 'Bearer '+ token
          }
      }).then((response)=>{
              
        if(response.status==200)
        {
          NotificationManager.success("recent Transactions Fetched Successfully", "Success", 4000);
          set_all_trans(response.data)
        
        }
        else

        {
        
          NotificationManager.error(response.data.value, "Error", 4000);
        }





      }).catch((err)=>{
        console.log(err)
         NotificationManager.error(JSON.stringify(err.response.data.errors), "Error", 4000);
       });
      
    }, [test]);


    

    return(
        <div className='dashboard-content'>
            <DashboardHeader/>

            <div className='dashboard-content-container'>
                <div className='dashboard-content-header'>
                    <h2>Transactions List</h2>
                    {/* <div className='dashboard-content-search'>
                        <input
                            type='text'
                            value={search}
                            placeholder='Search..'
                            className='dashboard-content-input'
                            onChange={e => __handleSearch(e)} />
                    </div> */}
                </div>

                <table>
                    <thead>
                        <th>From</th>
                        <th>To </th>
                        <th>Type</th>
                        <th>Date</th>
                        
                        <th>Amount</th>
                    </thead>

                    {all_trans.length !== 0 ?
                        <tbody>
                            {all_trans.map((order, index) => (
                                <tr key={index}>
                                    <td><span>{order.accNum}</span></td>
                                    <td><span>{order.toAccNum}</span></td>
                                    <td>
                                        <div>
                                            {/* {order.transType === 'Deposit' ?
                                                // <img
                                                //     src={DoneIcon}
                                                //     alt='paid-icon'
                                                //     className='dashboard-content-icon' />
                                                <p>Deposit</p>
                                            : order.status === 'Withdraw' ?
                                                <img
                                                    src={CancelIcon}
                                                    alt='canceled-icon'
                                                    className='dashboard-content-icon' />
                                            :  null} */}
                                            {}
                                            <span>{order.transType}</span>
                                        </div>
                                    </td>
                                    
                                    <td><span>{order.transDateTime}</span></td>
                                    <td><span>₹{order.amount}</span></td>
                                </tr>
                            ))}
                        </tbody>
                    : null}
                </table>

            </div>
        </div>
    )
}

export default Orders;
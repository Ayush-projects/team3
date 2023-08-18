import React, {useState, useEffect} from 'react';
import DashboardHeader from './DashboardHeader';

import all_trans from '../constants/orders';
import {calculateRange, sliceData} from '../utils/table-pagination';

import '../styles/styles.css';
import DoneIcon from '../assets/icons/done.svg';
import CancelIcon from '../assets/icons/cancel.svg';
import RefundedIcon from '../assets/icons/refunded.svg';

function Orders () {
    const [search, setSearch] = useState('');
    const [orders, setOrders] = useState(all_trans);
    const [page, setPage] = useState(1);
    const [pagination, setPagination] = useState([]);

    useEffect(() => {
        setPagination(calculateRange(all_trans, 5));
        setOrders(sliceData(all_trans, page, 5));
    }, []);

    // Search
    const __handleSearch = (event) => {
        setSearch(event.target.value);
        if (event.target.value !== '') {
            let search_results = orders.filter((item) =>
                item.first_name.toLowerCase().includes(search.toLowerCase()) ||
                item.last_name.toLowerCase().includes(search.toLowerCase()) 
                //item.product.toLowerCase().includes(search.toLowerCase())
            );
            setOrders(search_results);
        }
        else {
            __handleChangePage(1);
        }
    };

    // Change Page 
    const __handleChangePage = (new_page) => {
        setPage(new_page);
        setOrders(sliceData(all_trans, new_page, 5));
    }

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
                        <th>Account Number</th>
                        <th>Date</th>
                        <th>Status</th>
                        <th>Costumer Name</th>
                        
                        <th>Amount</th>
                    </thead>

                    {all_trans.length !== 0 ?
                        <tbody>
                            {all_trans.map((order, index) => (
                                <tr key={index}>
                                    <td><span>{order.account_number}</span></td>
                                    <td><span>{order.date}</span></td>
                                    <td>
                                        <div>
                                            {order.status === 'Deposit' ?
                                                <img
                                                    src={DoneIcon}
                                                    alt='paid-icon'
                                                    className='dashboard-content-icon' />
                                            : order.status === 'Withdrawl' ?
                                                <img
                                                    src={CancelIcon}
                                                    alt='canceled-icon'
                                                    className='dashboard-content-icon' />
                                            : null}
                                            <span>{order.status}</span>
                                        </div>
                                    </td>
                                    
                                    <td><span>{order.first_name}</span></td>
                                    <td><span>${order.amount}</span></td>
                                </tr>
                            ))}
                        </tbody>
                    : null}
                </table>

                {orders.length !== 0 ?
                    <div className='dashboard-content-footer'>
                        {pagination.map((item, index) => (
                            <span 
                                key={index} 
                                className={item === page ? 'active-pagination' : 'pagination'}
                                onClick={() => __handleChangePage(item)}>
                                    {item}
                            </span>
                        ))}
                    </div>
                : 
                    <div className='dashboard-content-footer'>
                        <span className='empty-table'>No data</span>
                    </div>
                }
            </div>
        </div>
    )
}

export default Orders;
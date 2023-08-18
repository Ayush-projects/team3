import React from 'react'
import Banner from './Banner'
// import Button from 'react-bootstrap/Button';

function Home() {
    return (

        <div>
        
        <Banner/>  
        <div class="container" style={{marginTop: "80px"}}>
        <div class="row">
          <div class="col-lg-4" style={{textAlign: "center"}}>
           <img src="https://png.pngtree.com/png-vector/20191122/ourmid/pngtree-a-green-bag-with-dollar-vector-or-color-illustration-png-image_2017454.jpg" height="140" width="140" style={{borderRadius: "50%"}}></img>
            <h2>Transactions</h2>
            <p>We enable smooth money transfers and payments, enhancing business and personal transactions.</p>
           
          </div>
          <div class="col-lg-4"  style={{textAlign: "center"}}>
          <img src="https://cdn.dribbble.com/users/812639/screenshots/7085900/media/a2bc321f7b97b75a99be32921013b3e3.gif" height="140" width="140" style={{borderRadius: "50%"}}></img>
            <h2>Finance</h2>
            <p>We manage money, offer loans, and support economic growth through financial services.</p>
            
          </div>
          <div class="col-lg-4"  style={{textAlign: "center"}}>
          <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRh3nQvqNePqtZPxLeAckHC31ENGQUUghUoO7zZ24ktLabnfkMrX0S62DocRfGDEfRcA7g&usqp=CAU" height="140" width="140" style={{borderRadius: "50%"}}></img>
            <h2>Security</h2>
            <p>We prioitize safeguarding funds and data, implementing measures to prevent fraud and cyberattacks.</p>
          
          </div>
        </div>
        </div>
        </div>

    )
}

export default Home
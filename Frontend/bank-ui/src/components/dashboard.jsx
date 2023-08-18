import {React} from 'react'
import {useNavigate} from 'react-router-dom'
import '../styles/dashboard.css'
import Orders from './orders';
import Login from './Login'

// function Widget({ icon,value,name }) {
    
//   const navigate = useNavigate();

//    const handleClick = () =>{
//     navigate(name)
//    }

//     return (
//       <div className="widget" onClick={handleClick}>
//         <FontAwesomeIcon className='icon-1' icon={icon} size="2x" />
//         <h3 className = "widget-text">{value}</h3>
//       </div>
//     );
 
// }

  


const  Dashboard =() => {
   
   let isLoggedIn = localStorage.getItem("isLoggedIn")
   if(isLoggedIn=="true"){

    return (
      <Orders/>
    );
   }else 
   {
    return <Login/>
   }
  }

export default Dashboard
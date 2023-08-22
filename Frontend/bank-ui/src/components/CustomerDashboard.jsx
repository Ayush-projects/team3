import React, { Component } from 'react';
import styled from 'styled-components';
import CustomerData from './CustomerData';
import SearchBar from './SearchBar';
import DashboardHeader  from './DashboardHeader';
// Styled components
const PageContainer = styled.div`
  text-align: center;
  margin: 50px;
`;

const Heading = styled.h1`
  font-size: 24px;
  margin-bottom: 20px;
`;

const DataContainer = styled.div`
  border: 1px solid #ccc;
  padding: 20px;
  max-width: 300px;
  margin: 0 auto;
`;

const DataItem = styled.p`
  font-size: 16px;
  margin: 10px 0;
`;

class CustomerBankingDataPage extends Component {
  // ... (rest of the component code)

  render() {
    //const { accountNumber, customerId, accountBalance } = this.state.customerData;

    return (
      <PageContainer>
        {/* <DashboardHeader></DashboardHeader> */}
        {/* <CustomerData/> */}
        <SearchBar/>
      </PageContainer>
    );
  }
}

export default CustomerBankingDataPage;

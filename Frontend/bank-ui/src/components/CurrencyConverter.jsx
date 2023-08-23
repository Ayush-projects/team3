import React, { useState, useEffect } from 'react';
import axios from 'axios';
import CurrencyDropdown from './CurrencyDropdown';

const CurrencyConverter = () => {
  const [currencies, setCurrencies] = useState([]);
  const [fromCurrency, setFromCurrency] = useState('');
  const [toCurrency, setToCurrency] = useState('');
  const [amount, setAmount] = useState(1);
  const [conversionResult, setConversionResult] = useState('');

  useEffect(() => {
    axios.get('https://api.exchangeratesapi.io/latest')
      .then(response => {
        const availableCurrencies = Object.keys(response.data.rates);
        setCurrencies(availableCurrencies);
        setFromCurrency(availableCurrencies[0]);
        setToCurrency(availableCurrencies[1]);
      })
      .catch(error => {
        console.error('Error fetching currency rates:', error);
      });
  }, []);

  useEffect(() => {
    if (fromCurrency && toCurrency) {
      axios.get(`https://api.exchangeratesapi.io/latest?base=${fromCurrency}`)
        .then(response => {
          const rate = response.data.rates[toCurrency];
          const result = (amount * rate).toFixed(2);
          setConversionResult(result);
        })
        .catch(error => {
          console.error('Error fetching conversion rate:', error);
        });
    }
  }, [fromCurrency, toCurrency, amount]);

  const handleFromCurrencyChange = event => {
    setFromCurrency(event.target.value);
  };

  const handleToCurrencyChange = event => {
    setToCurrency(event.target.value);
  };

  const handleAmountChange = event => {
    setAmount(event.target.value);
  };

  return (
    <div className="currency-converter">
      <h2>Currency Converter</h2>
      <CurrencyDropdown
        currencies={currencies}
        selectedCurrency={fromCurrency}
        onChange={handleFromCurrencyChange}
      />
      <input
        type="number"
        value={amount}
        onChange={handleAmountChange}
      />
      <CurrencyDropdown
        currencies={currencies}
        selectedCurrency={toCurrency}
        onChange={handleToCurrencyChange}
      />
      <div className="conversion-result">
        {conversionResult && (
          <p>
            {amount} {fromCurrency} = {conversionResult} {toCurrency}
          </p>
        )}
      </div>
    </div>
  );
};

export default CurrencyConverter;

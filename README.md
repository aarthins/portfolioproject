# portfolioproject
This project needs the input txt file in the below format
 MS-50,FB-100
 GOOG-100,MS-50
 
 Each line in the above file is called portfolio.
 In this project , above mentioned txt file will the read in the code . And each stock symbols price shall retrieved using api call to
 https://www.alphavantage.co/documentation/function=BATCH_STOCK_QUOTES
 The batch stock quotes API enables the querying of multiple stock quotes with a single API request, updated realtime. It may serve as a lightweight alternative to our core stock time series
 two limitation in the above api is 
  1.US stock quotes during US market hours through this API.
  2.Up to 100 stock symbols seperated by comma. For example: symbols=MSFT,FB,AAPL. If more than 100 symbols are included, the API will return quotes for the first 100 symbols.
  
 at a time we can get the price all the stocks mentioned in the file and then for each line in the portfolio , volume * stock price is done.
 And overall Price is calculated for each portfolio
 overall price is displayed in the descending order.
 

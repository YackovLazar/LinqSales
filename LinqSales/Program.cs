var salesPriceOver10 = from sale in sales                       
                       where sale.PricePerItem > 10
                       select sale;

var salesSingleQuantityInDescendingOrder = from sale in sales
                                           where sale.Quantity == 1
                                           orderby sale.PricePerItem descending
                                           select sale;

var teaSalesWithoutExpediting = from sale in sales
                                where sale.Item == "Tea" && !sale.ExpeditedShipping
                                select sale;

var salesTotalOrderOver100 = from sale in sales
                             where sale.PricePerItem * sale.Quantity > 100
                             select sale;

var salesOfObjectWithItemPropertyAndTotalPricePropertyAndShippingStringWithExpeditedAndSalesIfLLC =
    from sale in (from sale in sales
        where sale.Customer.ToLower().Contains("llc")
        select new
        {
            Item = sale.Item,
            TotalPrice = (sale.PricePerItem * sale.Quantity) as double?,
            Shipping = sale.Address + (sale.ExpeditedShipping ? "EXPEDITE" : ""),

        })
        orderby sale.TotalPrice
    select sale;
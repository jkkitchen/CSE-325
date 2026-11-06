1. Evidence showing existing pizzas and additional pizza:
HTTP/1.1 200 OK
Connection: close
Content-Type: application/json; charset=utf-8
Date: Fri, 30 Oct 2026 02:59:31 GMT
Server: Kestrel
Transfer-Encoding: chunked

[
  {
    "id": 1,
    "name": "Classic Italian",
    "isGlutenFree": false
  },
  {
    "id": 2,
    "name": "Veggie",
    "isGlutenFree": true
  },
  {
    "id": 3,
    "name": "Meat Lovers",
    "isGlutenFree": false
  }
]


2. The requests and responses I received including the returned status code:

GET
**Request:**
GET {{ContosoPizza_HostAddress}}/pizza/
Accept: application/json

###

**Response and Status Code:**
HTTP/1.1 200 OK
Connection: close
Content-Type: application/json; charset=utf-8
Date: Fri, 30 Oct 2026 02:59:31 GMT
Server: Kestrel
Transfer-Encoding: chunked

[
  {
    "id": 1,
    "name": "Classic Italian",
    "isGlutenFree": false
  },
  {
    "id": 2,
    "name": "Veggie",
    "isGlutenFree": true
  },
  {
    "id": 3,
    "name": "Meat Lovers",
    "isGlutenFree": false
  }
]

-----------------------------
GET(id)
**Request:**
GET {{ContosoPizza_HostAddress}}/pizza/3
Accept: application/json

###

**Response and Code:**
HTTP/1.1 200 OK
Connection: close
Content-Type: application/json; charset=utf-8
Date: Fri, 30 Oct 2026 03:01:35 GMT
Server: Kestrel
Transfer-Encoding: chunked

{
  "id": 3,
  "name": "Meat Lovers",
  "isGlutenFree": false
}

-----------------------------
POST
**Request:**
POST {{ContosoPizza_HostAddress}}/pizza/
Content-Type: application/json

{
    "name": "Pepperoni",
    "isGlutenFree": false
}

###

**Response and Code:**
HTTP/1.1 201 Created
Connection: close
Content-Type: application/json; charset=utf-8
Date: Fri, 30 Oct 2026 03:02:48 GMT
Server: Kestrel
Location: https://localhost:7294/Pizza/4
Transfer-Encoding: chunked

{
  "id": 4,
  "name": "Pepperoni",
  "isGlutenFree": false
}

----------------------------------
PUT
**Request:**
PUT {{ContosoPizza_HostAddress}}/pizza/4
Content-Type: application/json

{
    "id": 4,
    "name": "Pepperoni Party",
    "isGlutenFree": false
}

###

**Response and Code:**
HTTP/1.1 204 No Content
Connection: close
Date: Fri, 30 Oct 2026 03:03:43 GMT
Server: Kestrel

-----------------------------------
DELETE
**Request:**
DELETE {{ContosoPizza_HostAddress}}/pizza/4

###

**Response and Code:**
HTTP/1.1 204 No Content
Connection: close
Date: Fri, 30 Oct 2026 03:04:25 GMT
Server: Kestrel


3. Text copy of working sales summary function:
void SalesSummary(IEnumerable<string> salesFiles, double salesTotal)
{
    StringBuilder report = new StringBuilder();    
    report.AppendLine("Sales Summary");
    report.AppendLine(new string('-', 20));
    report.AppendLine($"Total Sales: {salesTotal:C}");
    report.AppendLine();
    report.AppendLine("Details:");

    //Use loop to generate for each file
    foreach (string file in salesFiles)
    {
        // Calculate the sales total for this file
        var fileSalesTotal = CalculateSalesTotal(new[] { file }); //creates an array containing just the current file

        // Get the filename
        var fileName = Path.GetFileName(file);

        // Append the filename and its total to the report
        report.AppendLine($"\t{fileName}: {fileSalesTotal:C}");
    }

    //Generate file and save to folder salesTotalDir
    File.WriteAllText(
    Path.Combine(salesTotalDir, "SalesSummary.txt"),
    report.ToString()
);
}

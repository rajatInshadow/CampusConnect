import axios from "axios";

console.log("baseurl ","https://localhost:7139/api" )

const apiClient = axios.create({
    baseURL:"https://localhost:7139/api",
    headers: {
        "Content-Type": "application/json"
    }
});

export default apiClient;
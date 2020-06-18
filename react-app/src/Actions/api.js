import axios from "axios";

const baseUrl = "http://localhost:59044/api/";

export default {


    empresa(url = baseUrl + 'empresas/') {
        return {
            fetchAll: () => axios.get(url),
        }
    },

    escrever(url = baseUrl + '/empresas/escrever/') {
        return {
            fetch: empresaId => axios.get(url + empresaId)
        }
    },

    escreverTodos(url = baseUrl + '/empresas/escreverTodos') {
        return {
            fetch: () => axios.get(url)
        }
    },
}
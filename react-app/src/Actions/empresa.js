import api from "./api";

export const ACTION_TYPES = {
    FETCH_ALL:'FETCH_ALL'
}

export const fetchAll = () => dispatch =>{
    // Get 
    api.empresa().fetchAll()
    .then(response => {
            dispatch({
                type: ACTION_TYPES.FETCH_ALL,
                payload: response.data
            })
        }

    )
    .catch(err => console.log(err))
}

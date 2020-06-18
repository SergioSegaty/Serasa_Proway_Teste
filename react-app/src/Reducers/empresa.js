import {ACTION_TYPES} from "../Actions/empresa";
const initalState = {
    list: [],
    texto: {}
}

export const empresa = (state = initalState, action) => {

    switch (action.type) {
        case ACTION_TYPES.FETCH_ALL:
            return {
                ...state,
                list: [...action.payload]
            }
        default:
            return state
    }

}
import { getAllPointsThunkCreator } from './point-reducer';
import { Dispatch } from 'react';

enum  InitializeActionType {
    INITIALIZED_SUCCSESS = 'INITIALIZED_SUCCSESS'
}

interface IInitializedState {
    initialized: boolean
}

interface InitializedSuccessAction {
    type: InitializeActionType.INITIALIZED_SUCCSESS
}

type InitializeAction = InitializedSuccessAction

let initialState:IInitializedState = {
    initialized: false,
}

export const appReducer = (state = initialState, action: InitializeAction):IInitializedState => {
    switch (action.type) {
        case InitializeActionType.INITIALIZED_SUCCSESS:
            return {
                ...state, initialized: true
            }
        default:
            return state;
    }
}

export const initializedSuccess = ():InitializedSuccessAction  => {
    return { type: InitializeActionType.INITIALIZED_SUCCSESS };
}

export const initializeThunkCreator  = () => {
    return async (dispatch: Dispatch<any>) => {
        try {
            dispatch(getAllPointsThunkCreator());
            dispatch(initializedSuccess());
        } catch (error) {

        }
    }
}
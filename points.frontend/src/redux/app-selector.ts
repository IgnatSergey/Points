import type { RootState } from './store'

export const getInitializedStatus = (state: RootState) => {
    return state.app.initialized;
}
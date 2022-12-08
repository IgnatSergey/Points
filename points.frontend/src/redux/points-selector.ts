import type { RootState } from './store'

export const getPoints = (state: RootState) => {
    return state.point.points;
}
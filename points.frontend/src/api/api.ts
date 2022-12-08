import { IPoint } from './../types/types';
import axios from 'axios';

const host = axios.create({
    baseURL: process.env.REACT_APP_API_URL
})

export const pointAPI = {
    getPoints(): Promise<IPoint[]> {
        return host.get(`point`).then((response) => {
            return response.data.points
        })
    },

    deletePoint(pointId: string) {
        return host.delete(`point/${pointId}`).then((response) => {
            return response
        })
    }
}

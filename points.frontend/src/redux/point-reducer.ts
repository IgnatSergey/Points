import { IPoint } from './../types/types';
import { pointAPI } from "../api/api";
import { Dispatch } from 'react';

enum  PointActionType {
  GET_ALL_POINTS = 'GET-ALL-POINTS',
  DELETE_POINT = 'DELETE-POIN'
}

interface IPointsState {
  points: IPoint[]
}

interface getAllPointsAction {
  type: PointActionType.GET_ALL_POINTS, points: IPoint[]
}

interface deletePointPointsAction {
  type: PointActionType.DELETE_POINT, pointId: string
}

export type PointAction = getAllPointsAction | deletePointPointsAction 

let initialState: IPointsState = {
  points: [],
};

export const pointReducer = (state = initialState, action: PointAction):IPointsState => {
  switch (action.type) {
    case PointActionType.GET_ALL_POINTS:
      return {
        ...state,
        points: action.points,
      };
      case PointActionType.DELETE_POINT:
      return {
        ...state,
        points: state.points.filter((point: any) => point.id !== action.pointId),
      };
    default:
      return state;
  }
};

export const getAllPoints = (points: IPoint[]):getAllPointsAction => {
    return { type: PointActionType.GET_ALL_POINTS, points};
}

export const deletePoint = (pointId: string):deletePointPointsAction => {
  return { type: PointActionType.DELETE_POINT, pointId};
}

export const getAllPointsThunkCreator = () => {
    return async (dispatch: Dispatch<PointAction>) => {
        try {
            const response = await pointAPI.getPoints();
            dispatch(getAllPoints(response));
        } catch (error) {

        }
    }
}

export const deletePointThunkCreator = (pointId: string) => {
  return async (dispatch: Dispatch<PointAction>) => {
      try {
          await pointAPI.deletePoint(pointId);
          dispatch(deletePoint(pointId));
      } catch (error) {

      }
  }
}
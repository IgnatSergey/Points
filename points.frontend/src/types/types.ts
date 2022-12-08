export interface IPoint {
    id: string,
    positionX: number, 
    positionY: number, 
    radius: number, 
    color: number, 
    comments: IComment[]
}

export interface IComment {
    id: string,
    text: string, 
    backgroundColor: number, 
}